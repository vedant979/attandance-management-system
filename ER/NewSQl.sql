SELECT * FROM attendancemanagement.reportss;
DELIMITER //

CREATE TRIGGER after_insert_attendance
AFTER INSERT
ON Attendance
FOR EACH ROW
BEGIN
    DECLARE current_absent INT DEFAULT 0;
    DECLARE current_halfday INT DEFAULT 0;
    DECLARE current_present INT DEFAULT 0;

    -- Determine the type of attendance (absent, half-day, present)
    IF NEW.Status = 'Absent' THEN
        SET current_absent = 1;
    ELSEIF NEW.Status = 'Half-day' THEN
        SET current_halfday = 1;
    ELSEIF NEW.Status = 'Present' THEN
        SET current_present = 1;
    END IF;

    -- Check if a reports record exists for this member_id
    IF EXISTS (SELECT 1 FROM reports WHERE Member_id = NEW.Member_id) THEN
        -- Update the existing reports record
        UPDATE reports
        SET TotalAbsent = TotalAbsent + current_absent,
            TotalHalfDay = TotalHalfDay + current_halfday,
            TotalPresent = TotalPresent + current_present
        WHERE member_id = NEW.member_id;
    ELSE
        -- Insert a new reports record
        INSERT INTO reports (member_id, TotalAbsent, TotalHalfDay, TotalPresent)
        VALUES (NEW.member_id, current_absent, current_halfday, current_present);
    END IF;
END //

DELIMITER ;
DROP TRIGGER  after_insert_attendance;
