package com.uniminuto.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.http.ResponseEntity;

import com.uniminuto.model.AccounntModel;

public interface AccountRepository extends JpaRepository<AccounntModel, Integer> {

	AccounntModel findByCuenta(String cuenta);
	
	
}
