package org.com.schoolsystem.core.interfaces;

import java.util.List;

import org.com.schoolsystem.core.entities.Student;
import org.com.schoolsystem.core.entities.ViewStudents;
import org.com.schoolsystem.core.queryFilters.CourseFilter;
import org.springframework.data.repository.CrudRepository;

public interface StudentRepository extends CrudRepository<Student,Integer>{
    List<ViewStudents> GetStudents();
    List<Object> GetStudentsCourse(CourseFilter filter);
}
