package com.wallapop.katacombs.context.game.domain.create

import com.wallapop.katacombs.context.game.domain.Game
import com.wallapop.katacombs.context.game.domain.GameRepository
import com.wallapop.katacombs.context.user.domain.UserId
import org.springframework.stereotype.Service

@Service
class PlayerCreator(private val repository: GameRepository) {

    operator fun invoke(userId: UserId) {
        repository.save(Game(userId))
    }

}
