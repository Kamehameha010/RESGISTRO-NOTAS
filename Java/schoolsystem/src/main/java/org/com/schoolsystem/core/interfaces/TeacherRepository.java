package org.com.schoolsystem.core.interfaces;

import java.util.List;

import org.com.schoolsystem.core.entities.Teacher;
import org.com.schoolsystem.core.entities.ViewTeachers;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

public interface TeacherRepository extends CrudRepository<Teacher, Integer> {

    @Query(value = "Select * from vwteacheruser", nativeQuery = true)
    List<ViewTeachers> findTeachers();
}
