﻿using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess db;
    public UserData(ISqlDataAccess db)
    {
        this.db = db;
    }

    public async Task<IEnumerable<UserModel>> GetUsers()
    {
        return await db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });
    }

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    public async Task InsertUser(UserModel user)
    {
        await db.SaveData("dbo.spUser_Insert", new { FirstName = user.FirstName, LastName = user.LastName });
    }
    public async Task UpdateUser(UserModel user)
    {
        await db.SaveData("dbo.spUser_Update", user);
    }
    public async Task DeleteUser(int id)
    {
        await db.SaveData("dbo.spUser_Delete", new { Id = id });
    }

}
