package org.com.schoolsystem.core.interfaces;

import java.util.List;
import java.util.Optional;

import org.com.schoolsystem.core.entities.Course;

public interface CourseService {
    void save(Course entity);

    Optional<Course> findCoursebyId(int id);

    List<Course> getCourses();

    boolean deleteById(int id);
}
