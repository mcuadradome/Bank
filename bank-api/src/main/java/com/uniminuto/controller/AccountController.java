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
import com.uniminuto.model.AccounntModel;
import com.uniminuto.model.UserModel;
import com.uniminuto.repository.AccountRepository;
import com.uniminuto.repository.UserRepository;

@RestController
@RequestMapping("/api/v1")
public class AccountController {

	
	private static final Logger logger = LoggerFactory.getLogger(UserController.class);
	
	
	@Autowired
	private AccountRepository accountRepository;
	
	@GetMapping("/account")
	public List<AccounntModel> getAllAccountr() {
		// logger.info("Get all the employees...");
		return accountRepository.findAll();
	}

	@GetMapping("/account/{id}")
	public ResponseEntity<AccounntModel> getUserById(@PathVariable(value = "id") Integer Id)
			throws ResourceNotFoundException {
		AccounntModel employee = accountRepository.findById(Id)
				.orElseThrow(() -> new ResourceNotFoundException("User not found for this id :: " + Id));
		return ResponseEntity.ok().body(employee);
	}
	
	@GetMapping("/account/accountByNumber/{number}")	
	public ResponseEntity<AccounntModel> getUserByName(@PathVariable("number") String cuenta) throws ResourceNotFoundException {
		AccounntModel employee = accountRepository.findByCuenta(cuenta);
		
		return ResponseEntity.ok().body(employee);
	}
}
