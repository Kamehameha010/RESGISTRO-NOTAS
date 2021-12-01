package org.com.schoolsystem.core.interfaces;

import java.util.List;

import org.com.schoolsystem.core.entities.Course;
import org.springframework.data.repository.CrudRepository;

public interface CourseRepository extends CrudRepository<Course, Integer> {
    public List<Course> GetCourses();
}
