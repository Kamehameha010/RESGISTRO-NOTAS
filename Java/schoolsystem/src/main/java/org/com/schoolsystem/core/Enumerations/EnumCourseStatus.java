package org.com.schoolsystem.core.Enumerations;

import java.util.Hashtable;
import java.util.Map;

public enum EnumCourseStatus {

    ENABLED(1), DISABLED(2);

    private int m_value;

    private EnumCourseStatus(int value) {
        m_value = value;
    }

    private static Map<Object, Object> map = new Hashtable<>();
    static {
        for (var taskStatus : EnumCourseStatus.values()) {
            map.put(taskStatus.m_value, taskStatus);
        }
    }

    public static EnumCourseStatus valueOf(int taskStatus) {
        return (EnumCourseStatus) map.get(taskStatus);
    }

    public int getValue() {
        return m_value;
    }
}
