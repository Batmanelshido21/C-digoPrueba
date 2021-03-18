-- MySQL Script generated by MySQL Workbench
-- Wed Jan 27 02:46:32 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `serviciochat` ;

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `serviciochat` DEFAULT CHARACTER SET utf8 ;
USE `serviciochat` ;

-- -----------------------------------------------------
-- Table `mydb`.`Amigo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`Amigo` (
  `idAmigo` INT NOT NULL AUTO_INCREMENT,
  `nombreUsuario` VARCHAR(100) NOT NULL,
  `amigoNombreUsuario` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idAmigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Chat`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`Chat` (
  `nombreChat` VARCHAR(100) NOT NULL,
  `tipoChat` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`nombreChat`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Chat_has_UsuarioChat`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`Chat_has_UsuarioChat` (
  `Chat_nombreChat` VARCHAR(100) NOT NULL,
  `UsuarioChat_nombreUsuario` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Chat_nombreChat`, `UsuarioChat_nombreUsuario`),
  INDEX `fk_Chat_has_UsuarioChat_UsuarioChat1_idx` (`UsuarioChat_nombreUsuario` ASC) VISIBLE,
  INDEX `fk_Chat_has_UsuarioChat_Chat1_idx` (`Chat_nombreChat` ASC) VISIBLE,
  CONSTRAINT `fk_Chat_has_UsuarioChat_Chat1`
    FOREIGN KEY (`Chat_nombreChat`)
    REFERENCES `serviciochat`.`Chat` (`nombreChat`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Chat_has_UsuarioChat_UsuarioChat1`
    FOREIGN KEY (`UsuarioChat_nombreUsuario`)
    REFERENCES `serviciochat`.`UsuarioChat` (`nombreUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Mensaje`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`Mensaje` (
  `idMensaje` INT NOT NULL AUTO_INCREMENT,
  `fecha` DATE NOT NULL,
  `favorito` TINYINT NOT NULL,
  `mensaje` VARCHAR(1000) NULL,
  `tipoMensaje` VARCHAR(45) NOT NULL,
  `idMensajeImagen` INT NOT NULL,
  `idMensajeAudio` INT NULL,
  `UsuarioChat_nombreUsuario` VARCHAR(100) NOT NULL,
  `Chat_nombreChat` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idMensaje`),
  INDEX `fk_Mensaje_UsuarioChat1_idx` (`UsuarioChat_nombreUsuario` ASC) VISIBLE,
  INDEX `fk_Mensaje_Chat1_idx` (`Chat_nombreChat` ASC) VISIBLE,
  CONSTRAINT `fk_Mensaje_UsuarioChat1`
    FOREIGN KEY (`UsuarioChat_nombreUsuario`)
    REFERENCES `serviciochat`.`UsuarioChat` (`nombreUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Mensaje_Chat1`
    FOREIGN KEY (`Chat_nombreChat`)
    REFERENCES `serviciochat`.`Chat` (`nombreChat`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Reaccion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`Reaccion` (
  `idReaccion` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idReaccion`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Reaccion_has_Mensaje`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`Reaccion_has_Mensaje` (
  `Reaccion_idReaccion` INT NOT NULL AUTO_INCREMENT,
  `Mensaje_idMensaje` INT NOT NULL,
  `UsuarioChat_nombreUsuario` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Reaccion_idReaccion`, `Mensaje_idMensaje`),
  INDEX `fk_Reaccion_has_Mensaje_Mensaje1_idx` (`Mensaje_idMensaje` ASC) VISIBLE,
  INDEX `fk_Reaccion_has_Mensaje_Reaccion1_idx` (`Reaccion_idReaccion` ASC) VISIBLE,
  INDEX `fk_Reaccion_has_Mensaje_UsuarioChat1_idx` (`UsuarioChat_nombreUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Reaccion_has_Mensaje_Reaccion1`
    FOREIGN KEY (`Reaccion_idReaccion`)
    REFERENCES `serviciochat`.`Reaccion` (`idReaccion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Reaccion_has_Mensaje_Mensaje1`
    FOREIGN KEY (`Mensaje_idMensaje`)
    REFERENCES `mydb`.`Mensaje` (`idMensaje`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Reaccion_has_Mensaje_UsuarioChat1`
    FOREIGN KEY (`UsuarioChat_nombreUsuario`)
    REFERENCES `serviciochat`.`UsuarioChat` (`nombreUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`UsuarioChat`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `serviciochat`.`UsuarioChat` (
  `nombreUsuario` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`nombreUsuario`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;