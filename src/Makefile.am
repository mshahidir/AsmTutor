## Makefile.am -- Process this file with automake to produce Makefile.in
bin_PROGRAMS = AsmTutor
AsmTutordir = $(includedir)/AsmTutor
AsmTutor_SOURCES = main.cpp events.cpp buffers.cpp
AsmTutor_HEADERS = asmtutor.h events.h buffers.h task.h
AM_CPPFLAGS = --std=c++0x -I$(top_srcdir) $(gtk_CFLAGS) $(gtksourceview_CFLAGS) -DDATADIR='"$(datadir)"'
AsmTutor_LDADD = $(gtk_LIBS) $(gtksourceview_LIBS)

