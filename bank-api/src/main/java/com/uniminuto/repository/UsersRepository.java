package com.uniminuto.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import com.uniminuto.model.UsersModel;

public interface UsersRepository extends JpaRepository<UsersModel, Integer>{

}
