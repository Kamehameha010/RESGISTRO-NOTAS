package org.com.schoolsystem.core.queryFilters;

import lombok.Getter;
import lombok.Setter;
import lombok.ToString;

@Getter
@Setter
@ToString
public class CourseFilter {

    private int studentId;
    private int teacherId;
    private String name;
    private int courseId;
    private String courseName;
}
