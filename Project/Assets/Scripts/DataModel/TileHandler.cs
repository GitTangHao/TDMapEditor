using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


public class TileHandler 
{
    static Dictionary<Type, ConstructorInfo> sTiles = new Dictionary<Type, ConstructorInfo>();

    public static void RegisterTile<T>() where T:Tile
    {
        Type tType = typeof(T);
        if (tType != null)
        {
            Type[] tArgs = new Type[1] { typeof(TiledMap) };
            ConstructorInfo tCi = tType.GetConstructor(tArgs);
            if (tCi != null)
            {
                sTiles[tType] = tCi;
            }
        }
    }

    public static T CreateTile<T>(TiledMap a_tiledMap) where T:Tile
    {
        Type tType = typeof(T);
        if (sTiles.ContainsKey(tType))
        {
            return sTiles[tType].Invoke(new object[]{a_tiledMap}) as T;
        }
        return default(T);
    }

}
