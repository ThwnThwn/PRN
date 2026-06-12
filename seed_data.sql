-- =============================================
-- SEED DATA: EventsThuanVCT & RoundsThuanVCT
-- DB: PRN222_HACKATHON
-- =============================================

-- Xóa data cũ (nếu muốn reset, bỏ comment)
-- DELETE FROM RoundsThuanVCT;
-- DELETE FROM EventsThuanVCT;
-- DBCC CHECKIDENT ('RoundsThuanVCT', RESEED, 0);
-- DBCC CHECKIDENT ('EventsThuanVCT', RESEED, 0);

-- =============================================
-- 1. INSERT Events
-- =============================================
INSERT INTO EventsThuanVCT (EventName, Description, Status, PublishDate, IsActive)
VALUES
    (N'FPT Hackathon 2025',       N'Cuộc thi lập trình sáng tạo dành cho sinh viên FPT toàn quốc.', 1, '2025-09-01 08:00:00', 1),
    (N'AI Innovation Challenge',  N'Hackathon về trí tuệ nhân tạo và machine learning.', 1, '2025-10-15 08:00:00', 1),
    (N'GreenTech Hackathon',      N'Giải pháp công nghệ cho môi trường bền vững.', 0, NULL, 1),
    (N'Fintech Sprint 2025',      N'Ý tưởng đổi mới trong lĩnh vực tài chính - ngân hàng.', 1, '2025-11-01 08:00:00', 1),
    (N'Health IT Hackathon',      N'Ứng dụng công nghệ trong y tế và chăm sóc sức khỏe.', 0, NULL, 0);

-- =============================================
-- 2. INSERT Rounds (FK -> EventsThuanVCT)
-- =============================================
-- Lấy ID vừa insert
DECLARE @e1 INT = (SELECT TOP 1 EventThuanVCTId FROM EventsThuanVCT WHERE EventName = N'FPT Hackathon 2025');
DECLARE @e2 INT = (SELECT TOP 1 EventThuanVCTId FROM EventsThuanVCT WHERE EventName = N'AI Innovation Challenge');
DECLARE @e3 INT = (SELECT TOP 1 EventThuanVCTId FROM EventsThuanVCT WHERE EventName = N'GreenTech Hackathon');
DECLARE @e4 INT = (SELECT TOP 1 EventThuanVCTId FROM EventsThuanVCT WHERE EventName = N'Fintech Sprint 2025');
DECLARE @e5 INT = (SELECT TOP 1 EventThuanVCTId FROM EventsThuanVCT WHERE EventName = N'Health IT Hackathon');

INSERT INTO RoundsThuanVCT (EventThuanVCTId, RoundName, Deadline, PromotionRule, SortOrder, Price)
VALUES
    -- FPT Hackathon 2025
    (@e1, N'Vòng Sơ Loại',   '2025-09-15 23:59:00', 50, 1, NULL),
    (@e1, N'Vòng Bán Kết',   '2025-10-01 23:59:00', 20, 2, 5000000.00),
    (@e1, N'Vòng Chung Kết', '2025-10-20 23:59:00', 5,  3, 20000000.00),

    -- AI Innovation Challenge
    (@e2, N'Idea Submission', '2025-10-25 23:59:00', 30, 1, NULL),
    (@e2, N'Prototype Demo',  '2025-11-05 23:59:00', 10, 2, 10000000.00),
    (@e2, N'Final Pitch',     '2025-11-20 23:59:00', 3,  3, 30000000.00),

    -- GreenTech Hackathon
    (@e3, N'Registration Round', '2025-12-01 23:59:00', 40, 1, NULL),
    (@e3, N'Solution Round',     '2025-12-15 23:59:00', 15, 2, 8000000.00),

    -- Fintech Sprint 2025
    (@e4, N'Pitch Round',  '2025-11-10 23:59:00', 25, 1, NULL),
    (@e4, N'Demo Round',   '2025-11-25 23:59:00', 8,  2, 15000000.00),
    (@e4, N'Finals',       '2025-12-10 23:59:00', 3,  3, 50000000.00),

    -- Health IT Hackathon
    (@e5, N'Open Round', '2026-01-15 23:59:00', 20, 1, NULL);

-- =============================================
-- Verify
-- =============================================
SELECT 
    e.EventThuanVCTId AS [Event ID],
    e.EventName,
    CASE e.Status WHEN 1 THEN 'Published' ELSE 'Draft' END AS [Status],
    e.IsActive,
    COUNT(r.RoundThuanVCTId) AS [Total Rounds]
FROM EventsThuanVCT e
LEFT JOIN RoundsThuanVCT r ON r.EventThuanVCTId = e.EventThuanVCTId
GROUP BY e.EventThuanVCTId, e.EventName, e.Status, e.IsActive
ORDER BY e.EventThuanVCTId;
