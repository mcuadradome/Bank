package com.uniminuto.controller;

import java.util.List;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.uniminuto.exception.ResourceNotFoundException;
import com.uniminuto.model.UserModel;
import com.uniminuto.repository.UserRepository;

@RestController
@RequestMapping("/api/v1")
public class UserController {

	private static final Logger logger = LoggerFactory.getLogger(UserController.class);

	@Autowired
	private UserRepository userRepository;

	@GetMapping("/user")
	public List<UserModel> getAllUser() {
		// logger.info("Get all the employees...");
		return userRepository.findAll();
	}

	@GetMapping("/user/{id}")
	public ResponseEntity<UserModel> getUserById(@PathVariable(value = "id") Integer Id)
			throws ResourceNotFoundException {
		UserModel employee = userRepository.findById(Id)
				.orElseThrow(() -> new ResourceNotFoundException("User not found for this id :: " + Id));
		return ResponseEntity.ok().body(employee);
	}
	
	@GetMapping("/user/userByName/{UserName}")	
	public UserModel getUserByName(@PathVariable("UserName") String name) throws ResourceNotFoundException {
		List<UserModel> employee = userRepository.findAll();
		
		for (UserModel userModel : employee) {
			if(userModel.getUserName().equals(name)) {
				return userModel;
			}
		}
			
		return null;
	}

}
