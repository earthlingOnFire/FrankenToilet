using UnityEngine;



namespace FrankenToilet.greycsont;


public static class DirectionRa
{
    private static Vector3 cachedDirection;
    private static bool cachedValid;

    public static void Reset() => cachedValid = false;

    public static Vector3 Randomize4Dir(Vector3 direction)
    {
        if (cachedValid) return cachedDirection;
        
        float originalMag = direction.magnitude;
        Vector3 flatDir = new Vector3(direction.x, 0f, direction.z);
        
        Vector3 right = Vector3.Cross(Vector3.up, flatDir);

        int r = Random.Range(0, 4);
        Vector3 chosenXZ = r switch
        {
            0 => flatDir,
            1 => -flatDir,
            2 => right,
            3 => -right,
            _ => flatDir
        };
        
        Vector3 combined = chosenXZ;
        combined.y = -direction.y;
        
        Vector3 result = combined.normalized * originalMag;
        

        cachedDirection = result;
        cachedValid = true;
        return cachedDirection;
    }
}