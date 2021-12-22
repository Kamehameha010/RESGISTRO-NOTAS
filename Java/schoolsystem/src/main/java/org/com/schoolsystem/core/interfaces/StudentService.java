package org.com.schoolsystem.core.interfaces;

import java.util.List;
import java.util.Optional;

import org.com.schoolsystem.core.entities.Student;

public interface StudentService {
    Student add(Student entity);

    void edit(Student entity);

    Optional<Student> findStudentById(int id);

    List<Object> findCourseByStudent(int id);

    List<Student> findStudents();
}
