package org.com.schoolsystem.core.services;

import java.util.List;
import java.util.Optional;

import org.com.schoolsystem.core.Enumerations.EnumCourseStatus;
import org.com.schoolsystem.core.entities.Course;
import org.com.schoolsystem.core.interfaces.CourseRespository;
import org.com.schoolsystem.core.interfaces.CourseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CourseServiceImpl implements CourseService {

    @Autowired
    private CourseRespository _respository;

    @Override
    public Optional<Course> findCoursebyId(int id) {
        return _respository.findById(id);
    }

    @Override
    public List<Course> getCourses() {
        return (List<Course>) _respository.findAll();
    }

    @Override
    public void save(Course entity) {
        _respository.save(entity);
    }

    @Override
    public boolean deleteById(int id) {
        if (_respository.existsById(id)) {
            var course = findCoursebyId(id).get();
            course.setCourseStatusId(EnumCourseStatus.DISABLED.getValue());
            save(course);
            return true;
        }
        return false;
    }
}
