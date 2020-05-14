package com.wallapop.katacombs.context.game.domain.create

import com.wallapop.katacombs.context.game.domain.Game
import com.wallapop.katacombs.context.game.domain.GameRepository
import com.wallapop.katacombs.context.user.domain.UserId

class GameCreator(private val repository: GameRepository) {

    operator fun invoke(userId: UserId) {
        repository.save(Game(userId))
    }

}
