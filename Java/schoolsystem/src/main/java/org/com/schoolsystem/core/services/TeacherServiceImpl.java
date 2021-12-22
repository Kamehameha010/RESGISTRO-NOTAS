package org.com.schoolsystem.core.services;

import java.util.List;
import java.util.Optional;

import org.com.schoolsystem.core.entities.Teacher;
import org.com.schoolsystem.core.entities.ViewTeachers;
import org.com.schoolsystem.core.interfaces.TeacherRepository;
import org.com.schoolsystem.core.interfaces.TeacherService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class TeacherServiceImpl implements TeacherService {

    @Autowired
    private TeacherRepository _repository;

    @Override
    public List<ViewTeachers> findTeachers() {
        return _repository.findTeachers();
    }

    @Override
    public Optional<ViewTeachers> findTeacherById(int id) {
        return findTeachers().stream().filter(x -> x.getTeacherId() == id).findFirst();
    }

    @Override
    public void save(Teacher entity) {
        _repository.save(entity);
    }

}
