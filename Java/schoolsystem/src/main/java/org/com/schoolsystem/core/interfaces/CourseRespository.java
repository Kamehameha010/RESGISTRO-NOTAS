package org.com.schoolsystem.core.interfaces;

import org.com.schoolsystem.core.entities.Course;
import org.springframework.data.repository.CrudRepository;

public interface CourseRespository extends CrudRepository<Course, Integer> {

}
