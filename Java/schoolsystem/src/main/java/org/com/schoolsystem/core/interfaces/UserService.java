package org.com.schoolsystem.core.interfaces;

import java.util.List;
import java.util.Optional;

import org.com.schoolsystem.core.entities.User;

public interface UserService {
    User add(User entity);

    void edit(User entity);

    Optional<User> findUserById(int id);

    List<User> getUsers();
}
