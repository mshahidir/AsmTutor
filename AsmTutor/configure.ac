#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT([AsmTutor], [0.1.6], [https://github.com/ScarletCarson/AsmTutor/issues])
AC_CONFIG_SRCDIR([src/buffers.c])
AC_CONFIG_HEADERS([config.h])

AM_INIT_AUTOMAKE([-Wall -Werror foreign])

# Checks for programs.
AC_PROG_CC

# Checks for libraries.
PKG_CHECK_MODULES([gtk], [gtk+-2.0],,
   echo "Missing library gtk+-2.0: Cannot continue";
exit)

PKG_CHECK_MODULES([gtksourceview], [gtksourceview-2.0],,
   echo "Missing library gtksourceview-2.0: Cannot continue";
exit)

# Checks for header files.
AC_CHECK_HEADERS([stdlib.h string.h unistd.h])

# Checks for typedefs, structures, and compiler characteristics.
AH_TEMPLATE([LDSOPATH], [LDSOPATH points to ld-linux])

AC_CHECK_FILE(/usr/lib/ld-linux.so.2,AC_DEFINE([LDSOPATH], ["/usr/lib"]),
   AC_CHECK_FILE(/lib/ld-linux.so.2,AC_DEFINE([LDSOPATH], ["/lib"]),
      echo "Missing ld-linux.so.2; Please file a bug report"
   exit)
)

# Checks for library functions.
AC_CHECK_FUNCS([strstr])

AC_CONFIG_FILES([Makefile src/Makefile])
AC_OUTPUT
