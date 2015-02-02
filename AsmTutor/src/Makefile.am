## Makefile.am -- Process this file with automake to produce Makefile.in
bin_PROGRAMS = AsmTutor 
AsmTutor_SOURCES = main.c asmtutor.h events.c events.h buffers.c buffers.h task.h
AM_CPPFLAGS = --std=c++0x -I$(top_srcdir) $(gtk_CFLAGS) $(gtksourceview_CFLAGS)
AsmTutor_LDADD = $(gtk_LIBS) $(gtksourceview_LIBS)

