-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema attendancemanagement
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema attendancemanagement
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `attendancemanagement` DEFAULT CHARACTER SET utf8mb3 ;
USE `attendancemanagement` ;

-- -----------------------------------------------------
-- Table `attendancemanagement`.`address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`address` (
  `address_id` CHAR(36) NOT NULL,
  `house_no` VARCHAR(45) NULL DEFAULT NULL,
  `street` VARCHAR(300) NULL DEFAULT NULL,
  `postal_code` VARCHAR(10) NULL DEFAULT NULL,
  `city` VARCHAR(45) NULL DEFAULT NULL,
  `state` VARCHAR(45) NULL DEFAULT NULL,
  `country` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`address_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`member`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`member` (
  `member_id` CHAR(36) NOT NULL,
  `first_name` VARCHAR(45) NULL DEFAULT NULL,
  `middle_name` VARCHAR(45) NULL DEFAULT NULL,
  `last_name` VARCHAR(45) NULL DEFAULT NULL,
  `dob` DATE NULL DEFAULT NULL,
  `gender` ENUM('male', 'female', 'other') NULL DEFAULT NULL,
  `hash_password` VARCHAR(400) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `roles` ENUM('admin', 'user') NULL DEFAULT NULL,
  PRIMARY KEY (`member_id`),
  UNIQUE INDEX `Id_UNIQUE` (`member_id` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`attendance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`attendance` (
  `attendance_id` CHAR(36) NOT NULL,
  `member_id` CHAR(36) NOT NULL,
  `attendance_date` DATE NOT NULL,
  `status` ENUM('Present', 'Absent', 'Late', 'On Leave') NOT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `logout_time` TIMESTAMP NOT NULL,
  `login_time` TIMESTAMP NOT NULL,
  PRIMARY KEY (`attendance_id`, `member_id`),
  INDEX `member_id` (`member_id` ASC) VISIBLE,
  CONSTRAINT `attendance_ibfk_1`
    FOREIGN KEY (`member_id`)
    REFERENCES `attendancemanagement`.`member` (`member_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`contact`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`contact` (
  `contact_id` CHAR(36) NOT NULL,
  `phone_number` INT NULL DEFAULT NULL,
  `member_id` CHAR(36) NOT NULL,
  `contact_type` ENUM('Personal', 'home', 'work') NULL DEFAULT NULL,
  PRIMARY KEY (`contact_id`, `member_id`),
  UNIQUE INDEX `contact_id_UNIQUE` (`contact_id` ASC) VISIBLE,
  INDEX `fk_Contact_Member1_idx` (`member_id` ASC) VISIBLE,
  CONSTRAINT `fk_Contact_Member1`
    FOREIGN KEY (`member_id`)
    REFERENCES `attendancemanagement`.`member` (`member_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`memberaddress`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`memberaddress` (
  `MemberAddress_id` CHAR(36) NOT NULL,
  `address_type` ENUM('current', 'permanent', 'work') NOT NULL,
  `member_id` CHAR(36) NOT NULL,
  `address_id` CHAR(36) NOT NULL,
  PRIMARY KEY (`MemberAddress_id`, `member_id`, `address_id`),
  INDEX `fk_MemberAddress_Member1_idx` (`member_id` ASC) VISIBLE,
  INDEX `fk_MemberAddress_Address1_idx` (`address_id` ASC) VISIBLE,
  CONSTRAINT `fk_MemberAddress_Address1`
    FOREIGN KEY (`address_id`)
    REFERENCES `attendancemanagement`.`address` (`address_id`),
  CONSTRAINT `fk_MemberAddress_Member1`
    FOREIGN KEY (`member_id`)
    REFERENCES `attendancemanagement`.`member` (`member_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`regularization_requests`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`regularization_requests` (
  `request_id` CHAR(36) NOT NULL,
  `member_id` CHAR(36) NOT NULL,
  `requested_date` DATE NOT NULL,
  `regularization_reason` VARCHAR(255) NULL DEFAULT NULL,
  `status` ENUM('Pending', 'Approved', 'Denied') NULL DEFAULT 'Pending',
  `updated_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`request_id`, `member_id`),
  INDEX `member_id` (`member_id` ASC) VISIBLE,
  CONSTRAINT `regularization_requests_ibfk_1`
    FOREIGN KEY (`member_id`)
    REFERENCES `attendancemanagement`.`member` (`member_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`reports`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`reports` (
  `report_id` CHAR(36) NOT NULL,
  `member_id` CHAR(36) NOT NULL,
  `report_month` DATE NOT NULL,
  `total_present` INT NULL DEFAULT '0',
  `total_absent` INT NULL DEFAULT '0',
  `total_late` INT NULL DEFAULT '0',
  `total_on_leave` INT NULL DEFAULT '0',
  `generated_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`report_id`, `member_id`),
  INDEX `member_id` (`member_id` ASC) VISIBLE,
  CONSTRAINT `reports_ibfk_1`
    FOREIGN KEY (`member_id`)
    REFERENCES `attendancemanagement`.`member` (`member_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `attendancemanagement`.`sessionlog`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `attendancemanagement`.`sessionlog` (
  `sessionlog_id` CHAR(36) NOT NULL,
  `token` VARCHAR(600) NOT NULL,
  `member_id` CHAR(36) NOT NULL,
  `IsValid` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`sessionlog_id`, `member_id`),
  INDEX `fk_SessionLog_Member1_idx` (`member_id` ASC) VISIBLE,
  CONSTRAINT `fk_SessionLog_Member1`
    FOREIGN KEY (`member_id`)
    REFERENCES `attendancemanagement`.`member` (`member_id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;

use attendancemanagement;
ALTER TABLE regularization_requests
ADD COLUMN attendance_id CHAR(36) NOT NULL UNIQUE,
ADD CONSTRAINT FK_Attendance_Regularization
FOREIGN KEY (attendance_id) REFERENCES attendance(attendance_id);
SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
