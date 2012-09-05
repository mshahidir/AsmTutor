#include <stdlib.h>
#include <glib.h>
#include <glib/gstdio.h>
#include <gtk/gtk.h>
#include <gtksourceview/gtksourceview.h>
#include <string.h>
#include <time.h>
#include <unistd.h>

#include "config.h"
#include "events.h"
#include "buffers.h"


/** info_dialog
 * Information button code
 */
void
info_dialog (GtkWidget *wid, GtkWidget *win) {
  GtkWidget *dialog = gtk_message_dialog_new (GTK_WINDOW (win),
								GTK_DIALOG_MODAL,
								GTK_MESSAGE_INFO,
								GTK_BUTTONS_CLOSE,
								INFO);
  gtk_window_set_position (GTK_WINDOW (dialog), GTK_WIN_POS_CENTER);
  gtk_dialog_run (GTK_DIALOG (dialog));
  gtk_widget_destroy (dialog);
}


/** test_answer
 * The Test Answer button code.
 */
void
test_answer(GtkWidget *wid, GtkWidget *win) {
  GtkTextIter chars, end;
  gchar * text;

  char *name = NULL,
       *nasm = NULL;

  asprintf(&name, "%s%08x", fn, time(NULL));
  asprintf(&nasm, "nasm -f elf -o %1$s.o %1$s", name);

  gtk_text_buffer_get_bounds(GTK_TEXT_BUFFER(gsv_buffer_asm), &chars, &end);
  text = gtk_text_buffer_get_text(GTK_TEXT_BUFFER(gsv_buffer_asm), &chars, &end, TRUE);

  g_file_set_contents(name, text, strlen(text), NULL);

  { /* Debug code */
	GtkWidget *dialog = gtk_message_dialog_new (GTK_WINDOW (win),
									GTK_DIALOG_MODAL,
									GTK_MESSAGE_INFO,
									GTK_BUTTONS_CLOSE,
									nasm);
	gtk_window_set_position (GTK_WINDOW (dialog), GTK_WIN_POS_CENTER);
	gtk_dialog_run (GTK_DIALOG (dialog));
	gtk_widget_destroy (dialog);
  }

  system(nasm);

  unlink(name);

  free(name);
  free(nasm);
}


/** delete_event
 * MITM for quit
 */
gboolean
delete_event(GtkWidget *wnd, GdkEvent *evnt, gpointer data) {
	return FALSE; // Quit immediately
}


/** destroy_wnd
 * Really quit
 */
void
destroy_wnd(GtkWidget *wnd, gpointer data){
	gtk_main_quit();
}
