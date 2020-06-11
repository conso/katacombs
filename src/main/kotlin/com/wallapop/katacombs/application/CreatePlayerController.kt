package com.wallapop.katacombs.application

import com.wallapop.katacombs.context.game.domain.create.PlayerCreator
import com.wallapop.katacombs.context.user.domain.UserId
import org.springframework.http.HttpStatus.CREATED
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.ResponseStatus
import org.springframework.web.bind.annotation.RestController


@RestController
class CreatePlayerController(val creator: PlayerCreator) {

    @PostMapping("/katacomb/player")
    @ResponseStatus(CREATED)
    fun createPlayer(@RequestBody createRequest: PlayerRequest) {

        creator.invoke(UserId.fromString(createRequest.player.sid))

    }

}
data class PlayerRequest(val player: Player)
data class Player(val sid: String, val name:String)