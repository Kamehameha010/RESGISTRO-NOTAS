package org.com.schoolsystem;


import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@SpringBootApplication
@EnableJpaRepositories("org.com.schoolsystem.core.interfaces")
public class SchoolsystemApplication {

	public static void main(String[] args) {
		SpringApplication.run(SchoolsystemApplication.class, args);
	}

}
