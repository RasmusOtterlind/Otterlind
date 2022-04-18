using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField createInput;
    [SerializeField] private TMP_InputField joinInput;
    [SerializeField] private TMP_Text rooms;
    private bool debug = true;

    private void Start()
    {
        Debug.Log(PhotonNetwork.CurrentLobby.Name);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("######UPDATELIST#####");
        rooms.text = "Rooms:\n";
        for (int i = 0; roomList.ToArray().Length > i; i++)
        {
            RoomInfo room = roomList.ToArray()[i];
            rooms.text += room.Name + "\n";
        }
       
    }
    private void DebugPrint(string debugString)
    {
        if (debug){
            Debug.Log(debugString);
        }
    }

    public void CreateRoom()
    {
        DebugPrint("The create input text is: " + createInput.text);
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        DebugPrint("The Joined input text is: " + joinInput.text);
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
        DebugPrint("Should have joined scene ");
    }
}
