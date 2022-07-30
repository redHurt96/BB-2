using UnityEngine;

namespace RH.Utilities.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 AddRandomInBox(this Vector3 origin, Vector3 size) =>
            origin + new Vector3(
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y),
                Random.Range(-size.z, size.z));
    }
}