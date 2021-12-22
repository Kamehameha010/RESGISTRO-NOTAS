package org.com.schoolsystem.api.controllers;

import org.com.schoolsystem.core.entities.Course;
import org.com.schoolsystem.core.interfaces.CourseService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/v1/courses")
public class CourseController {
    @Autowired
    private CourseService _service;

    @GetMapping()
    public ResponseEntity<?> getAll() {
        return ResponseEntity.ok(_service.getCourses());
    }

    @PostMapping()
    public ResponseEntity<?> Post(@RequestBody Course entity) {
        _service.save(entity);
        return ResponseEntity.ok(entity);
    }

    @PutMapping(value = "/{id}")
    public ResponseEntity<?> Put(@PathVariable Integer id, @RequestBody Course entity) {
        entity.setCourseId(id);
        _service.save(entity);
        return ResponseEntity.ok(entity);
    }

    @GetMapping(value = "/{id}")
    public ResponseEntity<?> find(@PathVariable Integer id) {
        return ResponseEntity.ok(_service.findCoursebyId(id));
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<?> Delete(@PathVariable Integer id) {
        return ResponseEntity.ok( _service.deleteById(id));
    }
}
