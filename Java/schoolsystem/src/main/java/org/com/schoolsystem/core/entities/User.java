package org.com.schoolsystem.core.entities;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import lombok.Data;

@Entity
@Table(name = "tb_user")
@Data
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "userid")
    private int userId;
    private int nid;
    private String name;
    private String lastname;
    private String address;
    private String phone;
    private String username;
    private String password;
    @Column(name = "rolid")
    private int rolId;

}
