package org.com.schoolsystem.core.entities;

public class Course {

    private int courseId;
    private String code;
    private String name;
    private int courseStatus;
    
    public int getCourseId() {
        return courseId;
    }
    public void setCourseId(int courseId) {
        this.courseId = courseId;
    }
    public String getCode() {
        return code;
    }
    public void setCode(String code) {
        this.code = code;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public int getCourseStatus() {
        return courseStatus;
    }
    public void setCourseStatus(int courseStatus) {
        this.courseStatus = courseStatus;
    }
    

}
