package com.uniminuto.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.uniminuto.exception.ResourceNotFoundException;
import com.uniminuto.model.UsersModel;
import com.uniminuto.repository.UsersRepository;

@RestController
@RequestMapping("/api/v1")
public class UsuarioController {

	
	@Autowired
	private UsersRepository usersRepository;
	
	@GetMapping("/users")
    public List<UsersModel> getAllUser() {
        //logger.info("Get all the employees...");
        return usersRepository.findAll();
    }
	
	
	 @GetMapping("/users/{id}")
	    public ResponseEntity<UsersModel> getUserById(@PathVariable(value = "id") Integer Id)
	        throws ResourceNotFoundException {
		 UsersModel employee = usersRepository.findById(Id)
	          .orElseThrow(() -> new ResourceNotFoundException("User not found for this id :: " + Id));
	        return ResponseEntity.ok().body(employee);
	    }
	 
	
	
	
}
