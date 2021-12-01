package org.com.schoolsystem.core.entities;

public class CourseStatus {
    private int courseStatusId;
    private String code;
    private String description;
    public int getCourseStatusId() {
        return courseStatusId;
    }
    public void setCourseStatusId(int courseStatusId) {
        this.courseStatusId = courseStatusId;
    }
    public String getCode() {
        return code;
    }
    public void setCode(String code) {
        this.code = code;
    }
    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
    }
    
}
