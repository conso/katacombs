package com.wallapop.katacombs.context.game.domain

import com.wallapop.katacombs.context.game.domain.Game

interface GameRepository {

    fun save(game: Game)

}
