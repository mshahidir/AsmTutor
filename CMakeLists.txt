cmake_minimum_required(VERSION 2.8.4)
project(AsmTutor)

find_package(PkgConfig REQUIRED)
pkg_check_modules (GLIB2 REQUIRED glib-2.0)
pkg_check_modules (GTK3 REQUIRED gtk+-3.0)

include_directories(${GTK3_INCLUDE_DIRS} ${GLIB2_INCLUDE_DIRS})
link_directories(${GTK3_LIBRARY_DIRS} ${GLIB2_LIBRARY_DIRS})
add_definitions(${GTK3_CFLAGS_OTHER} ${GLIB2_CFLAGS_OTHER})

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

set(SOURCE_FILES
    src/asmtutor.h
    src/buffers.cpp
    src/buffers.h
    src/events.cpp
    src/events.h
    src/main.cpp
    src/Makefile.am
    src/task.h)

add_executable(AsmTutor ${SOURCE_FILES})

target_link_libraries(AsmTutor ${GTK3_LIBRARIES} ${GLIB2_LIBRARIES} -lgtksourceview3)
