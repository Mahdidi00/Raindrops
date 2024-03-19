using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{
    public GameObject RaindropPrefab;
    public GameObject RaindropPrefabGold;
    private int SpawnChance = 20;
    private float SpawnCooldown = 2f;

    public List<Vector3> SpawnPoints = new List<Vector3>();
    List<Raindrop> SkyBox = new List<Raindrop>();

    public void CheckInput(string _value, int _difficulty, int _mode)
    {
        for (int i = 0; i < SkyBox.Count; i++)
        
        {
            if (SkyBox[i] != null && SkyBox[i].Result == _value)
            {
                if (isGolden(SkyBox[i], _difficulty, _mode))
                {
                    DestroyAllRaindrops();
                }
                else
                {
                    Raindrop Drop = SkyBox[i];
                    SkyBox.RemoveAt(i);
                    Destroy(Drop.gameObject);
                }
            }
        }
    }

    private bool isGolden(Raindrop _r, int _difficulty, int _mode)
    {
        switch (_difficulty)
        {
            case 0:

                if (_mode == 1)
                {
                    if (_r.MoveSpeed >= 0.4f + Time.time / 2000) return true;
                }
                else if (_r.MoveSpeed >= 0.8f + Time.time / 2000) return true;

                return false;

            case 1:

                if (_mode == 1)
                {
                    if (_r.MoveSpeed >= 0.6f + Time.time / 1500) return true;
                }
                else if (_r.MoveSpeed >= 1.2f + Time.time / 2000) return true;

                return false;

            case 2:

                if (_mode == 1)
                {
                    if (_r.MoveSpeed >= 0.8f + Time.time / 1500) return true;
                }
                else if (_r.MoveSpeed >= 1.6f + Time.time / 2000) return true;

                return false;

            default:

                return false;
        }
    }

    public void TryCreateRaindrop(int _difficulty, int _mode)
    {
        int chance = Random.Range(1,101);
        if (Time.time >= SpawnCooldown)
        {
            if (chance <= SpawnChance)
            {
                CreateRaindrop(_difficulty, _mode);
            }
            SpawnCooldown = Time.time + 1f;
            if(_difficulty == 0)
            {
                SpawnCooldown = Time.time + 4f;
            }
        }
    }

    private void CreateRaindrop(int _difficulty, int _mode)
    {
        int SpawnPoint = Random.Range(0,8);
        int GoldChance = Random.Range(1, 101);

        if (GoldChance <= 20)
        {
            GameObject newRaindrop = GameObject.Instantiate(RaindropPrefabGold, SpawnPoints[SpawnPoint], Quaternion.identity,transform);
            SkyBox.Add(newRaindrop.GetComponent<Raindrop>());
            SkyBox[SkyBox.Count - 1].MoveSpeed = 1.2f + Time.time / 1500;
            if(_mode == 1)
            {
                SkyBox[SkyBox.Count - 1].MoveSpeed = 0.6f + Time.time / 1500;
            }
            if(_difficulty == 0)
            {
                SkyBox[SkyBox.Count - 1].MoveSpeed = 0.8f + Time.time / 2000;
                if (_mode == 1)
                {
                    SkyBox[SkyBox.Count - 1].MoveSpeed = 0.4f + Time.time / 2000;
                }
            }
            else if(_difficulty == 2)
            {
                SkyBox[SkyBox.Count - 1].MoveSpeed = 1.6f + Time.time / 1000;
                if (_mode == 1)
                {
                    SkyBox[SkyBox.Count - 1].MoveSpeed = 0.8f + Time.time / 1000;
                }
            }
        }
        else
        {
            GameObject newRaindrop = GameObject.Instantiate(RaindropPrefab, SpawnPoints[SpawnPoint], Quaternion.identity,transform);
            SkyBox.Add(newRaindrop.GetComponent<Raindrop>());
            SkyBox[SkyBox.Count - 1].MoveSpeed = 1f + Time.time/1500;
            if (_mode == 1)
            {
                SkyBox[SkyBox.Count - 1].MoveSpeed = 0.5f + Time.time/1500;
            }
            if (_difficulty == 0)
            {
                SkyBox[SkyBox.Count - 1].MoveSpeed = 0.6f + Time.time / 2000;
                if (_mode == 1)
                {
                    SkyBox[SkyBox.Count - 1].MoveSpeed = 0.3f + Time.time / 2000;
                }
            }
            else if (_difficulty == 2)
            {
                SkyBox[SkyBox.Count - 1].MoveSpeed = 1.2f + Time.time/1000;
                if (_mode == 1)
                {
                    SkyBox[SkyBox.Count - 1].MoveSpeed = 0.6f + Time.time/1000;
                }
            }
        }

    }

    public void DestroyAllRaindrops()
    {
        for (int i = SkyBox.Count - 1; i >= 0; i--)
        {
            Raindrop Drop = SkyBox[i];
            SkyBox.RemoveAt(i);
            Destroy(Drop.gameObject);
        }
    }

}
