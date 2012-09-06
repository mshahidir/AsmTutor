#ifndef EVENTS_H_INCLUDED
#define EVENTS_H_INCLUDED

void
info_dialog (GtkWidget *wid, GtkWidget *win);

void
test_answer(GtkWidget *wid, GtkWidget *win);

gboolean
delete_event(GtkWidget *wnd, GdkEvent *evnt, gpointer data);

void
destroy_wnd(GtkWidget *wnd, gpointer data);

#endif // EVENTS_H_INCLUDED
