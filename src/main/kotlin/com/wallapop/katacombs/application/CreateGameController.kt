package com.wallapop.katacombs.application

import com.wallapop.katacombs.context.game.domain.create.GameCreator
import com.wallapop.katacombs.context.user.domain.UserId
import org.springframework.http.HttpStatus.CREATED
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.ResponseStatus
import org.springframework.web.bind.annotation.RestController


@RestController
class CreateGameController(val gameCreator: GameCreator) {

    @PostMapping("/start")
    @ResponseStatus(CREATED)
    fun createGame(@RequestBody createRequest: CreateRequest) {

        gameCreator(UserId.fromString(createRequest.userId))

    }

}

class CreateRequest(var userId: String)
