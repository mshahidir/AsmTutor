#ifndef CONFIG_H_INCLUDED
#define CONFIG_H_INCLUDED
#include <glib.h>

static gchar *searchpaths[] = {"./",
                               "/usr/share/gtksourceview-2.0/language-specs/",
                               NULL};

static const char
            *TITLE = "Asm Tutor",
			*fn    = "/tmp/asml1-",
			*INFO = "This application is designed to teach you assembler.\n\n"
                    "You will notice that there are two panes.\nThe first pane "
                    "contains the C source code, and the second is the box you "
                    "are expected to write your code into.\n\n"
                    "When you are done, the application will assemble your "
                    "code and test it. It is imperative that you don't rename "
                    "the method, unless you are faced with c's main function. "
                    "\n\nMain function tests are more relaxed but you should "
                    "name your functions _start instead of main.\n\n"
                    "    ---- Don't forget to set your functions global ----";

#endif // CONFIG_H_INCLUDED
