#include <stdlib.h>
#include <stdio.h>
#include <glib.h>
#include <gtk/gtk.h>
#include <gtksourceview/gtksourceview.h>
#include <string.h>
#include <time.h>
#include <unistd.h>

#include "task.h"
#include "asmtutor.h"
#include "events.h"
#include "buffers.h"

#define false 0
#define true 1


void
dialog (GtkWidget *wid, GtkWidget *win, const char * text) {
	GtkWidget *dialog = gtk_message_dialog_new (GTK_WINDOW (win),
							GTK_DIALOG_MODAL,
							GTK_MESSAGE_INFO,
							GTK_BUTTONS_CLOSE,
							"%s", text);

	gtk_window_set_position (GTK_WINDOW (dialog), GTK_WIN_POS_CENTER);
	gtk_dialog_run (GTK_DIALOG (dialog));
	gtk_widget_destroy (dialog);
	if (wid){};
}

void
info_dialog (GtkWidget *wid, GtkWidget *win) {
	dialog(wid, win, INFO);
}


/** save_answer
 * saves the answer to the filename returned.
 */
static void
save_buffer (GtkSourceBuffer *buff, const char *name) {
	GtkTextIter chars, end;
	gchar * text;

	gtk_text_buffer_get_bounds(GTK_TEXT_BUFFER(buff), &chars, &end);
	text = gtk_text_buffer_get_text(GTK_TEXT_BUFFER(buff), &chars, &end, TRUE);
	g_file_set_contents(name, text, strlen(text), NULL);
	free(text);
}

/** string_free
 * Frees the string and nullifies it.
 */
static void string_free(char ** string) {
	free(*string);
	*string = NULL;
}


/** unlink_free
 * unlinks a filename, and frees the name.
 */
static void
unlink_free(char ** filename) {
	unlink(*filename);
	string_free(filename);
}


/** load_and_test
 * Load the filename and test it
 */
int
load_and_test(const char *filename){
	char tmp[256] = {0};
	int win = 0;
	/* Do some magic loading and shit */
	FILE * program = popen(filename, "r");
	while (fgets(tmp, 256, program))
		if (!strncmp(correct, tmp, 256))
			win = 1;
	pclose(program);

	return win;
}

/** test_answer
 * The Test Answer button code.
 */
void
test_answer(GtkWidget *wid, GtkWidget *win) {
	char *name   = NULL,
		 *input  = NULL,
		 *output = NULL,
		 *dir    = g_get_current_dir(),
		 *cmd    = NULL;
	FILE *pout = NULL;
	char line[256] = {};
	int passed = 0;

	/* Setup the strings for saving the file */
	asprintf(&name,   "%s%08x.asm", prefix, (unsigned) time(NULL));
	asprintf(&output, "%s/%s", dir, name);

	/* Save the file */
	save_buffer(gsv_buffer_asm, output);

	/* Setup the strings for assembling the file */
	input = output;
	asprintf(&output, "%s/%s.o", dir, name);
	asprintf(&cmd, assembler_command, output, input);


	/* Assemble the file */
	pout = popen(cmd, "r");
	while (fgets(line, 256, pout)) {
		if (strstr(line, "error") || strstr(line, "warning")) {
			dialog(wid, win, "Error: Code contains errors or warnings.");
			free(name);
			free(input);
			free(output);
			free(dir);
			free(cmd);
			pclose(pout);
			return;
		}
	}
	pclose(pout);

	/* Cleanup/Setup the strings for linking the file */
	unlink_free(&input);
	string_free(&cmd);
	input = output;
	asprintf(&output, "%s/%s.exe", dir, name);
	asprintf(&cmd, linker_command, output, input);

	/* Link the file */
	pout = popen(cmd, "r");
	while (fgets(line, 256, pout)) {
		if (strstr(line, "error") || strstr(line, "warning")) {
			dialog(wid, win, "Error: Linker produced errors or warnings.");
			free(name);
			free(input);
			free(output);
			free(dir);
			free(cmd);
			pclose(pout);
			return;
		}
	}
	pclose(pout);

	passed = load_and_test(output);

	/* Clean up */
	string_free(&cmd);
	string_free(&name);
	unlink_free(&output);
	unlink_free(&input);

	if (passed)
		dialog(wid, win, "Congratulations password is: " passwd);
	else
		dialog(wid, win, "Nope, Thats not it.");

	if(wid&&win){};
}


/** delete_event
 * MITM for quit
 */
gboolean
delete_event(GtkWidget *wnd, GdkEvent *evnt, gpointer data) {
	if(wnd&&evnt&&data){};
	return FALSE; /* Quit immediately */
}


/** destroy_wnd
 * Really quit
 */
void
destroy_wnd(GtkWidget *wnd, gpointer data){
	gtk_main_quit();
	if(wnd&&data){};
}
