package com.uniminuto.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "CUENTAS")
public class AccounntModel {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer id;
	
	@Column(name = "id_user")
	private Integer idUser;
	
	@Column(name = "cuenta")
	private String cuenta;
	
	@Column(name = "state_ac")
	private Boolean StateAccount;
	
	
	public Integer getId() {
		return id;
	}
	public void setId(Integer id) {
		this.id = id;
	}
	public Integer getIdUser() {
		return idUser;
	}
	public void setIdUser(Integer idUser) {
		this.idUser = idUser;
	}
	public String getCuenta() {
		return cuenta;
	}
	public void setCuenta(String cuenta) {
		cuenta = cuenta;
	}
	public Boolean getStateAccount() {
		return StateAccount;
	}
	public void setStateAccount(Boolean stateAccount) {
		StateAccount = stateAccount;
	}
	
	
	
}
