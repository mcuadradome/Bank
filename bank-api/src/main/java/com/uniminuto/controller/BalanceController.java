package com.uniminuto.controller;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.uniminuto.model.AccounntModel;
import com.uniminuto.model.BalanceModel;
import com.uniminuto.repository.AccountRepository;
import com.uniminuto.repository.BalanceRepository;

@RestController
@RequestMapping("/api/v1")
public class BalanceController {

	@Autowired
	BalanceRepository balanceRepository;

	@Autowired
	AccountRepository accountRepository;

	@GetMapping("/balance")
	public List<BalanceModel> getAllBalance() {
		// logger.info("Get all the employees...");
		return balanceRepository.findAll();
	}

	@GetMapping("/balance/{cuenta}")
	public List<BalanceModel> getBalanceByAccount(@PathVariable(value = "cuenta") String cuenta) {

		AccounntModel accounntModel = accountRepository.findByCuenta(cuenta);

		List<BalanceModel> balance = balanceRepository.findByIdCuenta(accounntModel.getIdUser());
		return balance;
	}

	@PutMapping("/balance/{cuenta}")
	public ResponseEntity<BalanceModel> putBalanceByAccountr(@PathVariable(value = "cuenta") String cuenta,
			@RequestBody BalanceModel vaModel) {

		AccounntModel accounntModel = accountRepository.findByCuenta(cuenta);
		BalanceModel balance = balanceRepository.findBalanceByIdCuenta(accounntModel.getIdUser());

		balance.setNuevoSaldo(vaModel.getNuevoSaldo());
		balance.setSaldo(vaModel.getSaldo());

		BalanceModel updatedBalance = balanceRepository.save(balance);

		return ResponseEntity.ok(updatedBalance);
	}

	@PutMapping("/balance/transfer/{cuenta}/{cuenta2}")
	public ResponseEntity<BalanceModel> putTranseferByAccounts(@PathVariable(value = "cuenta") String cuenta,
			@PathVariable(value = "cuenta2") String cuenta2, @RequestBody BalanceModel valor) {

		AccounntModel accounntModel = accountRepository.findByCuenta(cuenta);
		AccounntModel accounntModel2 = accountRepository.findByCuenta(cuenta2);

		if (accounntModel.getStateAccount() && accounntModel2.getStateAccount()) {
			BalanceModel balance = balanceRepository.findBalanceByIdCuenta(accounntModel.getIdUser());

			if (balance.getSaldo().doubleValue() >= valor.getNuevoSaldo().doubleValue()) {
				BalanceModel balance2 = balanceRepository.findBalanceByIdCuenta(accounntModel2.getIdUser());

				double newValor = balance.getSaldo().doubleValue() - valor.getNuevoSaldo().doubleValue();
				double valorTranfer = balance2.getNuevoSaldo().doubleValue() + valor.getNuevoSaldo().doubleValue();

				balance.setNuevoSaldo(new BigDecimal(newValor));
				balance.setSaldo(new BigDecimal(newValor));

				balance2.setSaldo(balance2.getNuevoSaldo());
				balance2.setNuevoSaldo(new BigDecimal(valorTranfer));

				BalanceModel updatedBalance = balanceRepository.save(balance);
				BalanceModel updatedBalance2 = balanceRepository.save(balance2);

				return ResponseEntity.ok(updatedBalance2);

			} else {
				return null;
			}

		} else {
			return null;
		}

	}

}
