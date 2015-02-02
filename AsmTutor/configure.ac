#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT([AsmTutor], [0.1.6], [https://github.com/ScarletCarson/AsmTutor/issues])
AC_CONFIG_SRCDIR([src/buffers.c])
AC_CONFIG_HEADERS([config.h])

AM_INIT_AUTOMAKE([-Wall -Werror foreign])

# Templates
AH_TEMPLATE([LDSOPATH], [LDSOPATH points to ld-linux])
AH_TEMPLATE([NASMPATH], [NASMPATH points to nasm])

# Checks for programs.
AC_PROG_CC
NASM_LOC=$(which nasm)
if [ test ! NASM_LOC ]; then
   echo "Missing dependency nasm: Cannot continue";
   exit;
else
   AC_DEFINE_UNQUOTED([NASMPATH], "${NASM_LOC}")
fi

# Checks for libraries.
PKG_CHECK_MODULES([gtk], [gtk+-3.0],,
   echo "Missing library gtk+-3.0: Cannot continue";
exit)

PKG_CHECK_MODULES([gtksourceview], [gtksourceview-3.0],,
   echo "Missing library gtksourceview-3.0: Cannot continue";
exit)

# Checks for typedefs, structures, and compiler characteristics.
AC_CHECK_FILE(/usr/lib/ld-linux.so.2,AC_DEFINE([LDSOPATH], ["/usr/lib"]),
   AC_CHECK_FILE(/lib/ld-linux.so.2,AC_DEFINE([LDSOPATH], ["/lib"]),
      echo "Missing ld-linux.so.2; Please file a bug report"
   exit)
)

AC_CONFIG_FILES([Makefile src/Makefile])
AC_OUTPUT
