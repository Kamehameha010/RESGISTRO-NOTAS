package org.com.schoolsystem.core.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import lombok.Data;

@Entity
@Table(name = "tb_course_gradebook")
@Data
public class CourseGradeBook {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "coursegradebookid")
    public int courseGradebookId;
    @Column(name = "studentid")
    private int studentId;
    private double q1;
    private double q2;
    private double q3;
    private double average;
    @Column(name = "teacherid")
    private int teacherId;
    @Column(name = "courseid")
    private int courseId;
    private boolean status;

}
