SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema SiGDB
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema SiGDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `SiGDB` DEFAULT CHARACTER SET utf8 ;
USE `SiGDB` ;

-- -----------------------------------------------------
-- Table `SiGDB`.`roles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`roles` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(25) NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `role_name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`users` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `role_id` BIGINT NOT NULL,
  `username` VARCHAR(25) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `password_hash` TEXT NOT NULL,
  `full_name` VARCHAR(255) NOT NULL,
  `phone_number` VARCHAR(12) NOT NULL,
  `phone_number_last_four` VARCHAR(4) NOT NULL,
  `verification_code` VARCHAR(6) NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC) VISIBLE,
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `phone_number_UNIQUE` (`phone_number` ASC) VISIBLE,
  INDEX `phone_number_last_four` (`phone_number_last_four` ASC) VISIBLE,
  INDEX `fk_users_roles_idx` (`role_id` ASC) VISIBLE,
  CONSTRAINT `fk_users_roles`
    FOREIGN KEY (`role_id`)
    REFERENCES `SiGDB`.`roles` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`parks`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`parks` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `park_name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`shifts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`shifts` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `park_id` BIGINT NOT NULL,
  `status` ENUM("open", "closed") NOT NULL DEFAULT 'open',
  `type` ENUM("cars", "popcorn", "bouncer", "train", "carousel") NOT NULL,
  `opened_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `closed_at` DATETIME NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_shifts_park_idx` (`park_id` ASC) VISIBLE,
  CONSTRAINT `fk_shifts_park`
    FOREIGN KEY (`park_id`)
    REFERENCES `SiGDB`.`parks` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`positions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`positions` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `price_per_hour` DECIMAL(5,2) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `position_name_UNIQUE` (`name` ASC) INVISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`ticket_shifts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`ticket_shifts` (
  `id` BIGINT NOT NULL,
  `first_ticket` INT NOT NULL,
  `last_ticket` INT NULL,
  `ticket_price` DECIMAL(6,2) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_ticket_shifts_shifts1`
    FOREIGN KEY (`id`)
    REFERENCES `SiGDB`.`shifts` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`user_shifts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`user_shifts` (
  `user_id` BIGINT NOT NULL,
  `shift_id` BIGINT NOT NULL,
  `position_id` BIGINT NOT NULL,
  `joined_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `left_at` DATETIME NULL,
  PRIMARY KEY (`user_id`, `shift_id`),
  INDEX `fk_users_has_shift_shift1_idx` (`shift_id` ASC) VISIBLE,
  INDEX `fk_users_has_shift_users_idx` (`user_id` ASC) VISIBLE,
  INDEX `fk_user_shifts_positions1_idx` (`position_id` ASC) VISIBLE,
  CONSTRAINT `fk_users_has_shift_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `SiGDB`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_users_has_shift_shift`
    FOREIGN KEY (`shift_id`)
    REFERENCES `SiGDB`.`shifts` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_user_shifts_positions`
    FOREIGN KEY (`position_id`)
    REFERENCES `SiGDB`.`positions` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`cash_shifts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`cash_shifts` (
  `id` BIGINT NOT NULL,
  `cash` DECIMAL(18,2) NOT NULL,
  `cashless` DECIMAL(18,2) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_cash_shifts_shifts`
    FOREIGN KEY (`id`)
    REFERENCES `SiGDB`.`shifts` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`products` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `price` DECIMAL(10,2) NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `product_name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`cars` (
  `id` BIGINT NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `status` ENUM("working", "broken") NOT NULL DEFAULT 'working',
  `controller_model` VARCHAR(50) NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `car_name_UNIQUE` (`name` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`shift_cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`shift_cars` (
  `shift_id` BIGINT NOT NULL,
  `car_id` BIGINT NOT NULL,
  `joined_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `left_at` DATETIME NULL,
  PRIMARY KEY (`shift_id`, `car_id`),
  INDEX `fk_shifts_has_cars_cars_idx` (`car_id` ASC) VISIBLE,
  INDEX `fk_shifts_has_cars_shifts_idx` (`shift_id` ASC) VISIBLE,
  CONSTRAINT `fk_shifts_has_cars_shifts`
    FOREIGN KEY (`shift_id`)
    REFERENCES `SiGDB`.`shifts` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_shifts_has_cars_cars`
    FOREIGN KEY (`car_id`)
    REFERENCES `SiGDB`.`cars` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`shift_products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`shift_products` (
  `product_id` BIGINT NOT NULL,
  `shift_id` BIGINT NOT NULL,
  `quantity` INT NOT NULL,
  PRIMARY KEY (`product_id`, `shift_id`),
  INDEX `fk_products_has_shifts_shifts_idx` (`shift_id` ASC) VISIBLE,
  INDEX `fk_products_has_shifts_products_idx` (`product_id` ASC) VISIBLE,
  CONSTRAINT `fk_products_has_shifts_products`
    FOREIGN KEY (`product_id`)
    REFERENCES `SiGDB`.`products` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_products_has_shifts_shifts`
    FOREIGN KEY (`shift_id`)
    REFERENCES `SiGDB`.`shifts` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`train_shifts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`train_shifts` (
  `id` BIGINT NOT NULL,
  `first_ticket_alternative` INT NOT NULL,
  `last_ticket_alternative` INT NULL,
  `ticket_price_alternative` DECIMAL(6,2) NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_train_shifts_shifts`
    FOREIGN KEY (`id`)
    REFERENCES `SiGDB`.`shifts` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`rights`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`rights` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(75) NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`role_rights`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`role_rights` (
  `right_id` BIGINT NOT NULL,
  `role_id` BIGINT NOT NULL,
  PRIMARY KEY (`right_id`, `role_id`),
  INDEX `fk_rights_has_roles_roles_idx` (`role_id` ASC) VISIBLE,
  INDEX `fk_rights_has_roles_rights_idx` (`right_id` ASC) VISIBLE,
  CONSTRAINT `fk_rights_has_roles_rights`
    FOREIGN KEY (`right_id`)
    REFERENCES `SiGDB`.`rights` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_rights_has_roles_roles`
    FOREIGN KEY (`role_id`)
    REFERENCES `SiGDB`.`roles` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `SiGDB`.`history`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `SiGDB`.`history` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `user_id` BIGINT NULL,
  `entity_type` VARCHAR(50) NOT NULL,
  `entity_id` BIGINT NOT NULL,
  `action` ENUM("CREATED", "UPDATED", "DELETED") NOT NULL,
  `description` TEXT NULL,
  `timestamp` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_history_users_idx` (`user_id` ASC) VISIBLE,
  INDEX `entity_type_idx` (`entity_type` ASC) VISIBLE,
  INDEX `entity_id_idx` (`entity_id` ASC) VISIBLE,
  INDEX `action_idx` (`action` ASC) VISIBLE,
  CONSTRAINT `fk_history_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `SiGDB`.`users` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
