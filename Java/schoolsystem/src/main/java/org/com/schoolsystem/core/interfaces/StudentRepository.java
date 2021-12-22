package org.com.schoolsystem.core.interfaces;

import java.util.List;

import org.com.schoolsystem.core.entities.Student;
import org.com.schoolsystem.core.entities.ViewStudents;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

public interface StudentRepository extends CrudRepository<Student, Integer> {

    @Query(value = "Select * from vwstudentuser", nativeQuery = true)
    public List<ViewStudents> findStudents();
}
