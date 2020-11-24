package com.uniminuto.model;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "SALDO")
public class BalanceModel {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	private Integer id;
	
	@Column(name = "id_cuenta")
	private Integer idCuenta;

	@Column(name = "saldo")
	private BigDecimal Saldo;
	
	@Column(name = "nuevo_saldo")
	private BigDecimal NuevoSaldo;
	
	
	public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public Integer getIdCuenta() {
		return idCuenta;
	}
	public void setIdCuenta(Integer idCuenta) {
		this.idCuenta = idCuenta;
	}
	public BigDecimal getSaldo() {
		return Saldo;
	}
	public void setSaldo(BigDecimal saldo) {
		Saldo = saldo;
	}
	public BigDecimal getNuevoSaldo() {
		return NuevoSaldo;
	}
	public void setNuevoSaldo(BigDecimal nuevoSaldo) {
		NuevoSaldo = nuevoSaldo;
	}
	
}
