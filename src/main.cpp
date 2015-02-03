#include <stdlib.h>
#include <glib.h>
#include <glib/gstdio.h>
#include <gtk/gtk.h>
#include <gtksourceview/gtksourceview.h>
#include <gtksourceview/gtksourcebuffer.h>
#include <gtksourceview/gtksourcelanguagemanager.h>
#include <string>
#include <time.h>
#include <unistd.h>
#include "../config.h"

#include "asmtutor.h"
#include "task.h"
#include "events.h"
#include "buffers.h"

int
main (int argc, char *argv[]){
    GtkBuilder * builder = NULL;
	GtkWidget *button = NULL,
			*win = NULL,
			*vbox = NULL,
			*vbox2 = NULL,
			*halign = NULL,
			*buttonbox = NULL,
			*scrl1 = NULL,
			*scrl2 = NULL,
			*sourceview = NULL;
	GtkSourceLanguageManager *gsv_lm = NULL;
	GtkSourceLanguage *gsv_lang = NULL;
    std::string search_path = "./";

	gchar * searchpaths[] =
			{const_cast<gchar *>(search_path.c_str()),0};

	/* Initialize GTK+ */
	g_log_set_handler ("Gtk", G_LOG_LEVEL_WARNING, (GLogFunc) gtk_false, NULL);
	gtk_init (&argc, &argv);
	g_log_set_handler ("Gtk", G_LOG_LEVEL_WARNING, g_log_default_handler, NULL);

    builder = gtk_builder_new_from_file(DATADIR "/interface.ui");

	/* Create the main window */
	win = gtk_window_new (GTK_WINDOW_TOPLEVEL);
	gtk_container_set_border_width (GTK_CONTAINER (win), 8);
	gtk_window_set_title (GTK_WINDOW (win), TITLE);
	gtk_window_set_position (GTK_WINDOW (win), GTK_WIN_POS_CENTER);
	gtk_window_set_default_size(GTK_WINDOW(win), 600, 0);
	gtk_widget_realize (win);
	g_signal_connect (G_OBJECT(win), "destroy", G_CALLBACK(destroy_wnd), NULL);
	g_signal_connect (G_OBJECT(win), "delete_event", G_CALLBACK(delete_event),NULL);

	/* Create a vertical box with buttons */
	vbox = gtk_box_new(GTK_ORIENTATION_VERTICAL, 0);
	vbox2 = gtk_box_new(GTK_ORIENTATION_HORIZONTAL, 0);
	scrl1 = gtk_scrolled_window_new(0,0);
	scrl2 = gtk_scrolled_window_new(0,0);
	buttonbox = gtk_button_box_new(GTK_ORIENTATION_HORIZONTAL);

	gtk_container_add(GTK_CONTAINER(halign), buttonbox);
	gtk_box_pack_start(GTK_BOX(vbox2), GTK_WIDGET(scrl1), FALSE, TRUE, 0);
	gtk_box_pack_start(GTK_BOX(vbox2), GTK_WIDGET(scrl2), FALSE, TRUE, 0);
	gtk_widget_set_size_request(GTK_WIDGET(vbox2), 0, 400);

	gtk_container_add(GTK_CONTAINER(vbox), vbox2);
	gtk_container_add(GTK_CONTAINER(win), vbox);
	gtk_box_pack_start(GTK_BOX(vbox), halign, FALSE, FALSE, 0);

	gtk_scrolled_window_set_policy(GTK_SCROLLED_WINDOW(scrl1),
								GTK_POLICY_AUTOMATIC,
								GTK_POLICY_AUTOMATIC);

	gtk_scrolled_window_set_policy(GTK_SCROLLED_WINDOW(scrl2),
								GTK_POLICY_AUTOMATIC,
								GTK_POLICY_AUTOMATIC);


	/* Build the C buffer */
	if (!(gsv_lm = gtk_source_language_manager_new())) exit(1);
	gtk_source_language_manager_set_search_path(gsv_lm, searchpaths);
	if (!(gsv_lang = gtk_source_language_manager_get_language(gsv_lm, "c"))) exit(2);
    if (!(gsv_buffer_c = gtk_source_buffer_new_with_language(gsv_lang))) exit(3);
    gtk_source_view_new();
    gtk_source_view_new_with_buffer(gsv_buffer_c);
	gtk_source_buffer_set_highlight_syntax(gsv_buffer_c, TRUE);
	if (!(sourceview = gtk_source_view_new_with_buffer(gsv_buffer_c))) exit(4);
	gtk_container_add(GTK_CONTAINER(scrl1), sourceview);
	gtk_text_view_set_editable(GTK_TEXT_VIEW(sourceview), FALSE);
	gtk_text_view_set_cursor_visible(GTK_TEXT_VIEW(sourceview), FALSE);


	/* Build the ASM buffer */
	if (!(gsv_lm = gtk_source_language_manager_new())) exit(1);
	gtk_source_language_manager_set_search_path(gsv_lm, searchpaths);
	if (!(gsv_lang = gtk_source_language_manager_get_language(gsv_lm, "nasm"))) exit(2);
	if (!(gsv_buffer_asm = gtk_source_buffer_new_with_language(gsv_lang))) exit(3);
	gtk_source_buffer_set_highlight_syntax(gsv_buffer_asm, TRUE);
	if (!(sourceview = gtk_source_view_new_with_buffer(gsv_buffer_asm))) exit(4);
	gtk_container_add(GTK_CONTAINER(scrl2), sourceview);

	/* Set the text of the buffers */
	gtk_text_buffer_set_text(GTK_TEXT_BUFFER(gsv_buffer_c), question, strlen(question));
	gtk_text_buffer_set_text(GTK_TEXT_BUFFER(gsv_buffer_asm), answer, strlen(answer));

	/* Buttons */
    button = gtk_button_new_with_label("Info");
	g_signal_connect (G_OBJECT (button), "clicked", G_CALLBACK(info_dialog), (gpointer) win);
	gtk_box_pack_start (GTK_BOX (buttonbox), button, FALSE, FALSE, 0);

	button = gtk_button_new_with_label("Test Answer");
	g_signal_connect (button, "clicked", G_CALLBACK(test_answer), NULL);
	gtk_box_pack_start (GTK_BOX (buttonbox), button, FALSE, FALSE, 0);

	button = gtk_button_new_with_label ("Close");
	g_signal_connect (button, "clicked", gtk_main_quit, NULL);
	gtk_box_pack_start (GTK_BOX (buttonbox), button, FALSE, FALSE, 0);

	srand(time(NULL));

	/* Enter the main loop */
	gtk_widget_show_all (win);
	gtk_main ();
	return 0;
}
