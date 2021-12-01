package org.com.schoolsystem.core.entities;



public class CourseGradeBook {
    public int courseGradebookId;
        private int studentId;
        private double q1;
        private double q2;
        private double q3;
        private double average;
        private int teacherId;
        private int courseId;
        private boolean status;
        public int getCourseGradebookId() {
            return courseGradebookId;
        }
        public void setCourseGradebookId(int courseGradebookId) {
            this.courseGradebookId = courseGradebookId;
        }
        public int getStudentId() {
            return studentId;
        }
        public void setStudentId(int studentId) {
            this.studentId = studentId;
        }
        public double getQ1() {
            return q1;
        }
        public void setQ1(double q1) {
            this.q1 = q1;
        }
        public double getQ2() {
            return q2;
        }
        public void setQ2(double q2) {
            this.q2 = q2;
        }
        public double getQ3() {
            return q3;
        }
        public void setQ3(double q3) {
            this.q3 = q3;
        }
        public double getAverage() {
            return average;
        }
        public void setAverage(double average) {
            this.average = average;
        }
        public int getTeacherId() {
            return teacherId;
        }
        public void setTeacherId(int teacherId) {
            this.teacherId = teacherId;
        }
        public int getCourseId() {
            return courseId;
        }
        public void setCourseId(int courseId) {
            this.courseId = courseId;
        }
        public boolean isStatus() {
            return status;
        }
        public void setStatus(boolean status) {
            this.status = status;
        }
        
}
