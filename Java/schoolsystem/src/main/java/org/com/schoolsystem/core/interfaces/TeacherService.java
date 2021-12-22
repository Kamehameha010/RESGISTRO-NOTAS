package org.com.schoolsystem.core.interfaces;

import java.util.List;
import java.util.Optional;

import org.com.schoolsystem.core.entities.Teacher;
import org.com.schoolsystem.core.entities.ViewTeachers;

public interface TeacherService {
    void save(Teacher entity);

    Optional<ViewTeachers> findTeacherById(int id);

    List<ViewTeachers> findTeachers();
}
