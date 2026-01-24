CREATE TABLE "DiscountTable" (
                                 "Id" SERIAL PRIMARY KEY,
                                 "Code" TEXT NOT NULL,
                                 "Description" TEXT,
                                 "Status" TEXT DEFAULT 'ACTIVE'
);