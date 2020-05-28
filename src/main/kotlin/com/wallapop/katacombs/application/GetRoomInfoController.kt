package com.wallapop.katacombs.application

import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PathVariable
import org.springframework.web.bind.annotation.RestController

@RestController
class GetRoomInfoController() {
    @GetMapping("/katacomb/player/{playerId}")
    fun playerRoomInfo(@PathVariable playerId: String): RoomInfoRestResponse {

        return RoomInfoRestResponse("info", emptyList())

    }
}
    data class RoomInfoRestResponse(val description:String, val itemsId:List<String>)