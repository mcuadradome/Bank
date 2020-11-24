package com.uniminuto.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import com.uniminuto.model.BalanceModel;

public interface BalanceRepository extends JpaRepository<BalanceModel, Integer> {

	public List<BalanceModel> findByIdCuenta(Integer idCuenta);	
	public BalanceModel findBalanceByIdCuenta(Integer idCuenta);
	
}
