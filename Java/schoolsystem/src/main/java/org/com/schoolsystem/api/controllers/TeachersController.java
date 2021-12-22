package org.com.schoolsystem.api.controllers;

import java.util.List;

import org.com.schoolsystem.core.entities.Teacher;
import org.com.schoolsystem.core.entities.ViewTeachers;
import org.com.schoolsystem.core.interfaces.TeacherService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("api/v1/teachers")
public class TeachersController {

    @Autowired
    private TeacherService _service;

    @GetMapping()
    public ResponseEntity<?> teachers() {
        return ResponseEntity.ok(_service.findTeachers());
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> find(int id) {
        return ResponseEntity.ok(_service.findTeacherById(id));
    }

    @PostMapping()
    public ResponseEntity<?> Post(@RequestBody Teacher entity) {
        _service.save(entity);
        return ResponseEntity.ok(entity);
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> Put(@RequestBody Teacher entity) {
        _service.save(entity);
        return (ResponseEntity<?>) ResponseEntity.noContent();
    }

    

}
